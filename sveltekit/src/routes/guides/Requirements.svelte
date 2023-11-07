<script>
	export let isInitial = false;
	import { base } from '$app/paths';
	import Link from '$lib/Link.svelte';
</script>

<h2>Requirements</h2>
<ul>
	<li>BGME Framework</li>
	<li><Link url="{base}/guides/create-mod">Created a Music Mod with BGME Framework</Link></li>
	<li>Have your music script file opened in a text editor</li>
</ul>
{#if !isInitial}
	<blockquote>
		This guide builds off the previous one: <Link url="{base}/guides/randomized-bgm"
			>Adding Randomized BGM</Link
		>. If you don't want random BGM then you can just read through it and come back.
	</blockquote>
{/if}
