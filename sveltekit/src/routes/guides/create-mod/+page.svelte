<script>
	import { base } from '$app/paths';
	import Link from '$lib/Link.svelte';
</script>

<h1>Creating a Music Mod</h1>
<h2>Requirements</h2>
<ul>
	<li><em>Reloaded II</em> with <em>Persona Essentials</em> set up for your game.</li>
	<ul>
		<li>
			Persona 4 Golden: <Link url="https://gamebanana.com/tuts/15696" />
		</li>
		<li>
			Persona 5 Royal: <Link url="https://gamebanana.com/tuts/15399" />
		</li>
		<li>
			Persona 3 Portable: <Link url="https://gamebanana.com/tuts/15677" />
		</li>
	</ul>
	<li>
		Enable showing file extensions: <Link url="https://www.youtube.com/watch?v=6rOCUZ8opLM" />
	</li>
	<li>
		<b>(Optional)</b> Install <em>BGME Framework</em>, if you want to use extra features such as
		randomized BGM.
		<div>Download: TODO</div>
		<blockquote>
			<em>BGME Framework</em> can be added in the future, just remember to update your music mod's dependencies
			to include it.
		</blockquote>
	</li>
</ul>
<h2>Creating a Reloaded Mod</h2>
<ol>
	<li>
		Follow along with the official Reloaded II guide: <Link
			url="https://reloaded-project.github.io/Reloaded-II/CreatingMods/"
		/>
	</li>
	<li>
		On the section <b>Mod Dependencies</b>, look for and enable <em>Persona Essentials</em>. Also
		enable <em>BGME Framework</em> here, if you're using it.
	</li>
	<li>Continue and finish with the guide.</li>
	<li>Go to the game in Reloaded and enable your new mod.</li>
	<li>
		Select your mod in Reloaded, then click <em>Open Folder</em>. This folder is where all your
		mod's files will be placed.
	</li>
</ol>
<h2>Add a Music Script (BGME Framework)</h2>
<ol>
	<li>In your mod's folder, create a new folder and name it <em>BGME</em>.</li>
	<li>Inside that folder, right-click, select <em>New</em>, and select <em>Text Document.</em></li>
	<li>Replace the entire name, <b>including the .txt</b>, with <em>My Music Script.pme</em>.</li>
	<ul><li>You can name it whatever you want, as long as the name ends with <b>.pme</b>.</li></ul>
	<li>Select Yes when it asks you about changing the file extension.</li>
	<li>Double-click <em>My Music Script.pme</em> and open it with any text editor, like Notepad.</li>
</ol>
<p>
	This is where you will add your music script. Music script changes apply in real-time, so you can
	make changes while the game is running.
</p>
<p>
	If needed, you can also break up your music script into multiple files. <em>BGME Framework</em>
	will load all <b>.pme</b> music scripts found inside the <em>BGME</em> folder.
</p>
<p>
	<b>Continue: <Link url="{base}/guides/music-manager">Phos Music Manager</Link></b>
</p>
