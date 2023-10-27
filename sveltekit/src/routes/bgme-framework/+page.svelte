<div class="container">
	<div class="row">
		<div class="column">
			<h1>BGME Framework</h1>
			<p>
				<b>BGME Framework</b> is the core mod for loading and applying music scripts to Persona PC games.
				Other features also include adding support for new music, unlocking battle BGM, and applying
				music script changes in real-time.
			</p>
			<h2>Adding Music</h2>
			<p>
				BGM limits and restrictions are no more (mostly)! All three Persona games now support adding
				new music, with only Persona 4 Golden still having a hard limit.
			</p>
			<p>
				The process for adding new music is 99% the same as replacing music. The only differences
				are what you name the file and/or where you place it. If you haven't replaced music before,
				find a guide to do so for your game, and follow along until you name the file.
			</p>
			<h3>Persona 5 Royal</h3>
			<p>
				Place new audio tracks in <code>YOUR_MOD/FEmulator/AWB/BGM_42.AWB/</code>. Available audio
				tracks are
				<code>0.adx</code>
				up to <code>999.adx</code>.
			</p>
			<p>
				To use the new audio tracks, add <code>10000</code> to their ID, then use that value in your
				music script.
			</p>
			<h4>Example</h4>
			<ol>
				<li>
					Add audio track <code>400</code> by placing a new audio file at:
					<code>YOUR_MOD/FEmulator/AWB/BGM_42.AWB/400.adx</code>
				</li>
				<li>Adding <code>10000</code> to the ID gives you <code>10400</code>.</li>
				<li>Play the new audio track by using <code>10400</code> in your music script.</li>
			</ol>
			<h3>Persona 4 Golden</h3>
			<p>
				Use any audio in <code>snd00_bgm.awb</code> for BGM. To use the audio track in music script,
				just use the ID you used to replace it.
			</p>
			<blockquote><b>Tip:</b> Replace and use audio tracks 678 up to 835 for new music.</blockquote>
			<h4>Example</h4>
			<ol>
				<li>
					Replace audio track <code>678</code> by placing a new audio file at:
					<code>YOUR_MOD/FEmulator/AWB/snd00_bgm.awb/678.hca</code>
				</li>
				<li>Play the new audio track by using <code>678</code> in your music script.</li>
			</ol>
			<h3>Persona 3 Portable</h3>
			<p>
				Place new audio tracks in <code>YOUR_MOD/P5REssentials/CPK/BGME/data/sound/bgm/</code>. Max
				audio track is <code>99999999999.adx</code>, in theory at least.
			</p>
			<h4>Example</h4>
			<ol>
				<li>
					Add audio track <code>400</code> by placing a new audio file at:
					<code>YOUR_MOD/P5REssentials/CPK/BGME/data/sound/bgm/400.adx</code>
				</li>
				<li>Play the new audio track by using <code>400</code> in your music script.</li>
			</ol>
		</div>
	</div>
</div>
